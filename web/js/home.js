document.addEventListener("DOMContentLoaded", function () {
    // Dynamic welcome message
    const welcomeMessage = document.getElementById('lblWelcomeMessage');
    if (welcomeMessage) {
        welcomeMessage.textContent = "Hello, Student! Welcome back to your learning journey.";
    }

    // Add hover effect to navbar links
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        link.addEventListener('mouseenter', () => {
            link.style.color = '#00ff88';
        });
        link.addEventListener('mouseleave', () => {
            link.style.color = '#fff';
        });
    });

    // Add click effect to CTA button
    const ctaButton = document.querySelector('.cta-button');
    if (ctaButton) {
        ctaButton.addEventListener('click', () => {
            alert("Let's explore the courses together!");
        });
    }

    // Logout button functionality
    const logoutButton = document.getElementById('logout-button');
    if (logoutButton) {
        logoutButton.addEventListener('click', () => {
            // Redirect to logout page or perform logout action
            window.location.href = "logout.aspx"; // Replace with your logout URL
        });
    }
});