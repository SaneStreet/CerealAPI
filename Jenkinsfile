pipeline {
    agent any

    triggers {
        githubPush() // aktiveres af webhook
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/SaneStreet/CerealAPI.git'
            }
        }

        stage('Build .NET Project') {
            steps {
                echo '🏗️ Building .NET API...'
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                echo '🧪 Running tests...'
                sh 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Rebuild Containers') {
            steps {
                echo '♻️ Restarting Docker stack...'
                sh 'docker compose down'
                sh 'docker compose up -d --build'
            }
        }
    }
}

post {
    success {
            echo '✅ CI/CD pipeline completed successfully!'
    }

    failure {
        echo '❌ Build failed, check logs.'
    }
}