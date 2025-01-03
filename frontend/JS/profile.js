document.addEventListener('DOMContentLoaded', function() {
    fetch('/api/profile')
        .then(response => response.json())
        .then(data => {
            document.getElementById('name').textContent = data.name;
            document.getElementById('email').textContent = data.email;
            document.getElementById('level').textContent = data.level;
        })
        .catch(error => console.error('Error fetching profile data:', error));
});