pipeline {
    agent any

    stages {

        stage('Clean') {
            steps {
                dotnet clean wallet
                dotnet clean sportsbook
            }
        }

        stage('Build wallet') {
            steps {
                dotnet build wallet
            }
        }
        
        stage('Build sportsbook') {
            steps {
                dotnet build sportsbook
            }
        }
    }
}