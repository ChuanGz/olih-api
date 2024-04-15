node {
    stage('SCM') {
        checkout scm
      }
   
    stage('Analysis & Report') {
      timeout(time: 10, unit: 'MINUTES') {
        def scannerHome = tool 'SonarScanner for MSBuild'
        withSonarQubeEnv() {
          sh "
            dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"olih-api\" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
            dotnet build --no-incremental
            dotnet-coverage collect \"dotnet test\" -f xml -o \"coverage.xml\"
            dotnet ${scannerHome}/SonarScanner.MSBuild.dll end
            "
        }
      }
    }
}
