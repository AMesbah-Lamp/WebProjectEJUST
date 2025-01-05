document.addEventListener("DOMContentLoaded", function () {
    // Add hover effect to the enroll button
    const enrollButton = document.querySelector('.btn');
    if (enrollButton) {
        enrollButton.addEventListener('mouseenter', () => {
            enrollButton.style.transform = 'translateY(-5px)';
        });
        enrollButton.addEventListener('mouseleave', () => {
            enrollButton.style.transform = 'translateY(0)';
        });
    }
});