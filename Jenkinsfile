pipeline {
    agent any

    stages {

        stage('Clean') {
            steps {
                sh 'dotnet clean wallet'
                sh 'dotnet clean sportsbook'
            }
        }

        stage('Build wallet') {
            steps {
                sh 'dotnet build wallet'
            }
        }
        
        stage('Build sportsbook') {
            steps {
                sh 'dotnet build sportsbook'
            }
        }
    }
}