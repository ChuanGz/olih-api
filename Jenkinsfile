node {
    stage('SCM') {
        checkout scm
      }
    stage('Build') {
      sh '''
        export PATH=/var/jenkins_home/.dotnet/tools:$PATH
        export PATH=/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux:$PATH
        dotnet build
        '''
    }
    stage('UnitTest1') {
       sh '''
        export PATH=/var/jenkins_home/.dotnet/tools:$PATH
        export PATH=/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux:$PATH
        dotnet test --collect:\"Code Coverage\"
        '''
    }
    stage('Analysis & Report') {
      timeout(time: 10, unit: 'MINUTES') {
        def scannerHome = tool 'SonarScanner for MSBuild'
        withSonarQubeEnv() {
          sh '''
            export PATH=/var/jenkins_home/.dotnet/tools:$PATH
            export PATH=/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux:$PATH
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll begin /k:\"olih-api\" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
            dotnet build --no-incremental
            dotnet-coverage collect "var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet test" -f xml -o \"coverage.xml\"
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll end
            '''
        }
      }
    }
}
