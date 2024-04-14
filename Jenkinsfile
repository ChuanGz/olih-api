node {
  stage('Git Checkout') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    timeout(time: 10, unit: 'MINUTES') {
      def scannerHome = tool 'SonarScanner for MSBuild'
      withSonarQubeEnv() {
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"olih-api\""
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet build"
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet test --collect \"Code Coverage\"" 
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
      }
    }
  }
}
