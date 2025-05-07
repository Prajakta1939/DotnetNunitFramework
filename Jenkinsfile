pipeline {
    agent any

    environment {
        DOTNET_ROOT = '/usr/share/dotnet'  // Optional, depends on your setup
        PATH = "/usr/share/dotnet:${env.PATH}"  // Ensure dotnet is in PATH
        HOME = '/var/lib/jenkins'  // Ensure the HOME environment variable is set
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore DotnetProject/NUnitSeleniumFramework/TestAutomation/TestAutomation.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build DotnetProject/NUnitSeleniumFramework/TestAutomation/TestAutomation.csproj --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test DotnetProject/NUnitSeleniumFramework/TestAutomation/TestAutomation.csproj --logger "trx;LogFileName=test_results.trx"'
            }
        }
    }

    post {
        always {
            junit allowEmptyResults: true, testResults: '**/test_results.trx'  // Ensure correct file path
        }
    }
}
