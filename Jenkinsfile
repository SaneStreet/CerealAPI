pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/DIT_GITHUB_REPO_URL.git'
            }
        }

        stage('Build .NET Project') {
            steps {
                echo '🏗️ Building .NET API...'

                // Kør dotnet restore i SDK container
                sh '''
                docker run --rm \
                  -v $PWD:/app \
                  -w /app \
                  mcr.microsoft.com/dotnet/sdk:7.0 \
                  dotnet restore
                '''

                // Kør dotnet build i SDK container
                sh '''
                docker run --rm \
                  -v $PWD:/app \
                  -w /app \
                  mcr.microsoft.com/dotnet/sdk:7.0 \
                  dotnet build --configuration Release
                '''
            }
        }

        stage('Run Tests') {
            steps {
                echo '🧪 Running tests...'
                sh '''
                docker run --rm \
                  -v $PWD:/app \
                  -w /app \
                  mcr.microsoft.com/dotnet/sdk:7.0 \
                  dotnet test --no-build --verbosity normal
                '''
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

    post {
        success {
            echo '✅ CI/CD pipeline completed successfully!'
        }
        failure {
            echo '❌ Build or tests failed.'
        }
    }
}
