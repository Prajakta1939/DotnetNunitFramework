pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/Prajakta1939/DotnetNunitFramework.git', branch: 'main'
            }
        }

        stage('Restore') {
            steps {
                dir('NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Note: TRX format not supported by junit step. Convert to XML if needed.'
            }
        }
    }
}