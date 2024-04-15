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
    stage('UnitTest') {
       sh '''
        export PATH=/var/jenkins_home/.dotnet/tools:$PATH
        export PATH=/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux:$PATH
        dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
        '''
    }
    stage('Analysis & Report') {
      timeout(time: 10, unit: 'MINUTES') {
        def scannerHome = tool 'SonarScanner for MSBuild'
        withSonarQubeEnv() {
          sh '''
            export PATH=/var/jenkins_home/.dotnet/tools:$PATH
            export PATH=/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux:$PATH
            dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"olih-api\" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
            dotnet build --no-incremental
            dotnet-coverage collect \"dotnet test\" -f xml -o \"coverage.xml\"
            dotnet ${scannerHome}/SonarScanner.MSBuild.dll end
            '''
        }
      }
    }
}
