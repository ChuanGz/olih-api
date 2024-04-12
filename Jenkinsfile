node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    timeout(time: 1, unit: 'HOURS') {
      def scannerHome = tool 'SonarScanner for MSBuild'
      withSonarQubeEnv() {
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"olih-api\""
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet build"
        sh "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
      }
    }
  }
}
