/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            fontFamily: {
                opensans: ["'Open Sans'", "sans-serif"],
            },
            colors: {
                addGreen: "#45ada8",
                deletePink: "#ff6b6b",
                authorBlue: "#008c9e",
            },
        },
    },
    plugins: [require("daisyui")],
    daisyui: {
        themes: ["cupcake"],
    },
};
