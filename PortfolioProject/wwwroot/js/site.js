// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    document.addEventListener('DOMContentLoaded', function () {
        const scrollContent = document.querySelector('.scrollable-content');
    const scrollRightBtn = document.querySelector('.scroll-right-btn');
    const scrollLeftBtn = document.querySelector('.scroll-left-btn');

    // IMPORTANT: Get the width of the first card group. 
    // This is the exact distance we need to scroll.
    const firstCardGroup = document.querySelector('.card-group');
    let scrollStep = firstCardGroup ? firstCardGroup.offsetWidth : 0;

    // Function to recalculate scrollStep on window resize
    function updateScrollStep() {
            if (firstCardGroup) {
        scrollStep = firstCardGroup.offsetWidth;
            }
        }

    // Recalculate on resize to handle responsiveness
    window.addEventListener('resize', updateScrollStep);

    // Event listener for the right arrow button
    scrollRightBtn.addEventListener('click', function() {
        scrollContent.scrollBy({
            left: scrollStep, // Scroll right by the width of one visible group
            behavior: 'smooth'
        });
        });

    // Event listener for the left arrow button
    scrollLeftBtn.addEventListener('click', function() {
        scrollContent.scrollBy({
            left: -scrollStep, // Scroll left by the width of one visible group
            behavior: 'smooth'
        });
        });
    });




    //text animation

$(document).ready(function () {
    var fullText = "Here are some of my Projects that I have worked on. Many more to come!!"; // The text to be typed
    var textElement = $("#typewriter-text"); // The element to display the text
    var index = 0; // Current character index
    var speed = 75; // Typing speed in milliseconds per character

    function typeWriter() {
        if (index < fullText.length) {
            textElement.append(fullText.charAt(index)); // Append the current character
            index++; // Move to the next character
            setTimeout(typeWriter, speed); // Call the function again after a delay
        }
    }

    // Start the typing animation when the document is ready
    typeWriter();
});