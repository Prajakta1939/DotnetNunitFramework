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
                // Change directory to TestAutomation before running dotnet restore
                dir('TestAutomation') {
                    sh 'dotnet restore TestAutomation.csproj'
                }
            }
        }

        stage('Build') {
            steps {
                dir('TestAutomation') {
                    sh 'dotnet build TestAutomation.csproj --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('TestAutomation') {
                    sh 'dotnet test TestAutomation.csproj --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }
    }

    post {
        always {
            junit allowEmptyResults: true, testResults: '**/test_results.trx'  // Ensure correct file path
        }
    }
}
