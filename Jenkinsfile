pipeline {
    agent any

    environment {
        DOTNET_ROOT = "/usr/share/dotnet"
        PATH = "/usr/share/dotnet:${env.PATH}"
    }

    tools {
        // Ensure Jenkins has the .NET SDK configured if needed
        // dotnet 'your-dotnet-tool-name' // optional
    }

    stages {
        stage('Clone Repository') {
            steps {
                git 'https://github.com/Prajakta1939/DotnetNunitFramework.git'
            }
        }

        stage('Restore Dependencies') {
            steps {
                dir('TestAutomation') {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('TestAutomation') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Run Tests') {
            steps {
                dir('TestAutomation') {
                    sh 'dotnet test --no-build --configuration Release --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                junit allowEmptyResults: true, testResults: '**/TestResults/*.trx'
            }
        }
    }

    post {
        always {
            echo 'Pipeline finished.'
        }
    }
}

