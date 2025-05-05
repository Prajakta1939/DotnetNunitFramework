pipeline {
    agent any

   environment {
    REPO_URL = 'https://github.com/Prajakta1939/DotnetNunitFramework.git'
    PROJECT_PATH = 'DotnetProject/NUnitSeleniumFramework/TestAutomation'
    TEST_PROJECT_PATH = "${PROJECT_PATH}/TestAutomation.csproj"
}


    stages {
        stage('Checkout') {
            steps {
                git url: "${REPO_URL}", branch: 'main'
            }
        }

        stage('Restore') {
            steps {
                sh "dotnet restore ${TEST_PROJECT_PATH}"
            }
        }

        stage('Build') {
            steps {
                sh "dotnet build ${TEST_PROJECT_PATH} --configuration Release"
            }
        }

        stage('Test') {
            steps {
                sh "dotnet test ${TEST_PROJECT_PATH} --logger 'trx;LogFileName=test_results.trx'"
            }
        }

        stage('Publish Test Results') {
            steps {
                // If you’re using trx2junit to convert, use junit XML path here
                // Otherwise install MSTest plugin and use mstest step instead
                junit '**/test_results.trx'
            }
        }
    }
}
