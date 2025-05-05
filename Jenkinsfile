pipeline {
    agent any
    tools {
        dotnet 'dotnet-sdk-8.0' // Ensure this matches the name of your .NET SDK in Jenkins
    }
    environment {
        REPO_URL = 'https://github.com/Prajakta1939/DotnetNunitFramework.git'  // Your repository URL
        PROJECT_PATH = 'DotnetProject/NUnitSeleniumFramework/TestAutomation'  // Path to your project
        TEST_PROJECT_PATH = "${PROJECT_PATH}/DotnetProject/NUnitSeleniumFramework/TestAutomation.csproj"  // Path to the .csproj file
    }
    stages {
        stage('Checkout') {
            steps {
                git url: "${REPO_URL}", branch: 'main' // Checkout from the specified repo and branch
            }
        }
        stage('Restore') {
            steps {
                script {
                    // Run dotnet restore for the specified .csproj
                    sh "dotnet restore ${TEST_PROJECT_PATH}"
                }
            }
        }
        stage('Build') {
            steps {
                script {
                    // Build the project
                    sh "dotnet build ${TEST_PROJECT_PATH} --configuration Release"
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    // Run tests and generate the test results in .trx format
                    sh "dotnet test ${TEST_PROJECT_PATH} --logger 'trx;LogFileName=test_results.trx'"
                }
            }
        }
        stage('Publish Test Results') {
            steps {
                // Publish test results from the .trx file
                junit '**/test_results.trx'
            }
        }
    }
}
