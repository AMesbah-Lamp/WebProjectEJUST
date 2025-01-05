document.addEventListener("DOMContentLoaded", function () {
    // Add hover effect to cards
    const cards = document.querySelectorAll('.card');
    cards.forEach(card => {
        card.addEventListener('mouseenter', () => {
            card.style.transform = 'translateY(-5px)';
            card.style.boxShadow = '0 8px 25px rgba(0, 123, 255, 0.5)';
        });
        card.addEventListener('mouseleave', () => {
            card.style.transform = 'translateY(0)';
            card.style.boxShadow = 'none';
        });
    });

    // Add hover effect to logout button
    const logoutButton = document.querySelector('.logout-button');
    if (logoutButton) {
        logoutButton.addEventListener('mouseenter', () => {
            logoutButton.style.transform = 'translateY(-5px)';
            logoutButton.style.boxShadow = '0 8px 25px rgba(0, 123, 255, 0.5)';
        });
        logoutButton.addEventListener('mouseleave', () => {
            logoutButton.style.transform = 'translateY(0)';
            logoutButton.style.boxShadow = 'none';
        });
    }
});