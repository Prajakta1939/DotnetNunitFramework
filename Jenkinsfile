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
                dir('DotnetProject/NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet restore TestAutomation.csproj'
                }
            }
        }

        stage('Build') {
            steps {
                dir('DotnetProject/NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet build TestAutomation.csproj --configuration Release --no-restore'
                }
            }
        }

        stage('Test') {
            steps {
                dir('DotnetProject/NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet test TestAutomation.csproj --logger "trx;LogFileName=test_results.trx" --no-build --no-restore'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Note: TRX format is not directly supported by the JUnit plugin. Consider converting TRX to XML for integration.'
            }
        }
    }
}
