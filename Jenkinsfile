node {
   stage('Code Checkout') {
        checkout scm
      }

    stage('.NET Build') {
         sh "dotnet build"
      }

    stage('.NET Unit Test') {
         sh "dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura" 
      }

    stage('SonarQube Report') {
      timeout(time: 10, unit: 'MINUTES') {
        def scannerHome = tool 'SonarScanner for MSBuild'
        withSonarQubeEnv() {
          sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"olih-api\""
          sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet build"
          sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura" 
          sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
        }
      }
    }
  
}
