pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                echo '📥 Henter kode fra GitHub...'
                git branch: 'main', url: 'https://github.com/SaneStreet/CerealAPI.git'
            }
        }

        stage('Build & Publish Docker Image') {
            steps {
                echo '🏗️ Bygger Docker image...'
                sh 'docker compose build'
            }
        }

        stage('Run Tests') {
            steps {
                echo '🧪 Kører .NET tests...'
                sh 'docker run --rm cereal-api dotnet test --no-build --verbosity normal'
            }
        }

        stage('Deploy Stack') {
            steps {
                echo '🚀 Starter stack...'
                sh 'docker compose down'
                sh 'docker compose up -d'
            }
        }
    }

    post {
        success {
            echo '✅ CI/CD pipeline completed successfully!'
        }
        failure {
            echo '❌ Build failed — check Jenkins logs.'
        }
    }
    }
