node {
    stage('SCM') {
        checkout scm
      }
    stage('Build') {
      sh '''
        dotnet build
        '''
    }
    stage('UnitTest') {
       sh '''
        dotnet test --collect:\"Code Coverage\"
        '''
    }   
    stage('Code Analysis') {
      timeout(time: 10, unit: 'MINUTES') {
        withSonarQubeEnv() {
          sh '''
            export PATH=/var/jenkins_home/.dotnet/tools:$PATH          
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll begin /k:\"olih-api\" /d:sonar.cs.vscoveragexml.reportsPaths=TestReports/coverage.xml
            dotnet build --no-incremental
            dotnet-coverage collect \"dotnet test /p:CollectCoverage=true /p:IncludeTestAssembly=true /p:CoverletOutputFormat=cobertura\" -f xml -o \"TestReports/coverage.xml\"
            dotnet /var/jenkins_home/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScanner_for_MSBuild/SonarScanner.MSBuild.dll end
            '''
        }
      }
    }
}
