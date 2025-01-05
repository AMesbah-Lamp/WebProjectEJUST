document.addEventListener("DOMContentLoaded", function () {
    const loginToggle = document.getElementById("login-toggle");
    const signupToggle = document.getElementById("signup-toggle");
    const formWrapper = document.querySelector(".form-wrapper");

    loginToggle.addEventListener("click", function () {
        formWrapper.classList.remove("slide-left");
        loginToggle.classList.add("active");
        signupToggle.classList.remove("active");
    });

    signupToggle.addEventListener("click", function () {
        formWrapper.classList.add("slide-left");
        signupToggle.classList.add("active");
        loginToggle.classList.remove("active");
    });
});