node {
    stage('SCM') {
        checkout scm
      }
   
    stage('Analysis & Report') {
      timeout(time: 10, unit: 'MINUTES') {
        withSonarQubeEnv() {
          sh '''
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll begin /k:\"olih-api\" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
            dotnet build --no-incremental
            dotnet-coverage collect \"dotnet test\" -f xml -o \"coverage.xml\"
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll end
            '''
        }
      }
    }
}
