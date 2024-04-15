node {
    stage('SCM') {
        checkout scm
      }
   
    stage('Analysis & Report') {
      timeout(time: 10, unit: 'MINUTES') {
        withSonarQubeEnv() {
          sh '''
            export PATH=/var/jenkins_home/.dotnet/tools:$PATH          
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll begin /k:\"olih-api\" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
            dotnet build --no-incremental
            dotnet-coverage collect \"dotnet test /p:CollectCoverage=true\" -f xml -o \"coverage.xml\"
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll end
            '''
        }
      }
    }
}
