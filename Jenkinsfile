node {
    stage('SCM') {
        checkout scm
      }
    stage('Build') {
       changePathValue()
      sh '/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet build'
    }
    stage('UnitTest') {
      changePathValue()
      sh '/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura' 
    }
    stage('SonarQube Report') {
      changePathValue()
      timeout(time: 10, unit: 'MINUTES') {
        def scannerHome = tool 'SonarScanner for MSBuild'
        withSonarQubeEnv() {
          sh '/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:"olih-api" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml'
          sh '/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet build --no-incremental'
          sh '/var/jenkins_home/.dotnet/tools/dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"'
          sh '/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end'
        }
      }
    }
  void changePathValue() {
    try {
      PATH = '/var/jenkins_home/.dotnet/tools:$PATH'
      PATH = '/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/dotnet_8_linux:$PATH'
      sh 'echo $PATH'
      sh 'whoami'
    } catch(ex) {
      error("Error Details: ${ex.getMessage()}")
    }
  }
}
