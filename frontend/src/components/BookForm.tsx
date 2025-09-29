import { useState } from "react";

export default function BookForm({ onAdd }: { onAdd: (book: any) => void }) {
    const [title, setTitle] = useState("");
    const [authorId, setAuthorId] = useState("");
    const [genreId, setGenreId] = useState("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onAdd({
            title,
            authorId: Number(authorId),
            genreId: Number(genreId),
        });
        setTitle("");
        setAuthorId("");
        setGenreId("");
    };

    return (
        <form onSubmit={handleSubmit} className="flex flex-col gap-3 w-full max-w-md bg-base-100 p-4 shadow rounded-lg">
            <h2 className="text-xl font-bold">Add a New Book</h2>

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
                placeholder="Author Id"
                value={authorId}
                onChange={(e) => setAuthorId(e.target.value)}
                className="input input-bordered w-full"
                required
            />

            <input
                type="number"
                placeholder="Genre Id"
                value={genreId}
                onChange={(e) => setGenreId(e.target.value)}
                className="input input-bordered w-full"
                required
            />

            <button type="submit" className="btn btn-primary">Add Book</button>
        </form>
    );
}
