// frontend/src/components/BookForm.tsx
import { useState } from "react";
import * as React from "react";

type BookFormProps = {
    onClose: () => void;
};

export default function BookForm({ onClose }: BookFormProps) {
    const [title, setTitle] = useState("");
    const [authorId, setAuthorId] = useState("");
    const [genreId, setGenreId] = useState("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();

        // Later this will POST to your API
        console.log("New Book:", { title, authorId, genreId });

        alert(`Book "${title}" created!`);

        // Close the form after submit
        onClose();
    };

    return (
        <div className="bg-white shadow-xl rounded-lg p-6 w-96">
            <h2 className="text-xl font-semibold mb-4">Add a Book</h2>
            <form onSubmit={handleSubmit} className="flex flex-col gap-3">
                <input
                    type="text"
                    placeholder="Book Title"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    className="input input-bordered w-full"
                    required
                />
                <input
                    type="number"
                    placeholder="Author ID"
                    value={authorId}
                    onChange={(e) => setAuthorId(e.target.value)}
                    className="input input-bordered w-full"
                    required
                />
                <input
                    type="number"
                    placeholder="Genre ID"
                    value={genreId}
                    onChange={(e) => setGenreId(e.target.value)}
                    className="input input-bordered w-full"
                    required
                />

                <div className="flex justify-between mt-4">
                    <button type="submit" className="btn btn-primary">
                        Save
                    </button>
                    <button
                        type="button"
                        className="btn btn-ghost"
                        onClick={onClose}
                    >
                        Cancel
                    </button>
                </div>
            </form>
        </div>
    );
}
