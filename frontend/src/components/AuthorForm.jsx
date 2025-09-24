import { useState } from "react";

function AuthorForm({ onAuthorAdded }) {
    const [name, setName] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        const newAuthor = { name };

        const response = await fetch("http://localhost:5084/api/Author", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newAuthor),
        });

        if (response.ok) {
            setName("");
            if (onAuthorAdded) {
                onAuthorAdded(); // refresca la lista
            }
        } else {
            console.error("Error adding author");
        }
    };

    return (
        <form onSubmit={handleSubmit} className="p-6 bg-gray-100 rounded-lg shadow-md mb-6">
            <h2 className="text-lg font-bold mb-4">➕ Add Author</h2>
            <div className="mb-4">
                <label className="block mb-2 font-medium">Name:</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    className="border px-3 py-2 rounded w-full"
                    placeholder="Enter author name"
                    required
                />
            </div>
            <button
                type="submit"
                className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
            >
                Save
            </button>
        </form>
    );
}

export default AuthorForm;
