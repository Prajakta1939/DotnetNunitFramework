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

        stage('Publish Test Results') {
            steps {
                echo 'Note: TRX format not supported by junit step. Convert to XML if needed.'
            }
        }
    }
}
