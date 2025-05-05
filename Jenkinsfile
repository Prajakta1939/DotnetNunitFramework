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
                    sh 'dotnet restore TestAutomation.csproj'
                }
            }
        }
 
        stage('Build') {
            steps {
                dir('NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet build TestAutomation.csproj --configuration Release'
                }
            }
        }
 
        stage('Test') {
            steps {
                dir('NUnitSeleniumFramework/TestAutomation') {
                    sh 'dotnet test TestAutomation.csproj --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }
 
        stage('Publish Test Results') {
            steps {
                echo 'Note: .trx needs to be converted for JUnit plugin.'
                // Use a trx to junit converter tool if needed
            }
        }
    }
}