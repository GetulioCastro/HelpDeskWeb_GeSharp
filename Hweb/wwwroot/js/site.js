// Get a reference to the login button
const loginButton = document.getElementById('login-button');

// Add an event listener to the button
loginButton.addEventListener('click', () => {
    // Get the username and password from the input fields
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Send an AJAX request to the server to check the user's credentials
    fetch('/login/checkCredentials', {
        method: 'POST',
        body: JSON.stringify({ username, password }),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            // Handle the response from the server
            if (data.success) {
                // Redirect the user to the dashboard page
                window.location.href = '/dashboard';
            } else {
                // Display an error message to the user
                const errorMessage = document.getElementById('error-message');
                errorMessage.innerText = data.message;
                errorMessage.style.display = 'block'; // Show the error message
            }
        })
        .catch(error => console.error(error));
});