// src/App.tsx
import { useState, useEffect } from "react";
import BookForm from "./components/BookForm";


export default function App() {
    const [showForm, setShowForm] = useState(false);
    const [authors, setAuthors] = useState<any[]>([]);
    const [showAuthors, setShowAuthors] = useState(false);
    const [books, setBooks] = useState<any[]>([]);
    const [genres, setGenres] = useState<any[]>([]);

    useEffect(() => {
        fetch("http://localhost:5084/api/books")
            .then((res) => res.json())
            .then((data) => setBooks(data))
            .catch((err) => console.error("Error fetching books", err));

        fetch("http://localhost:5084/api/genres")
            .then((res) => res.json())
            .then((data) => setGenres(data))
            .catch((err) => console.error("Error fetching genres", err));
    }, []);

    useEffect(() => {
        if (showAuthors) {
            fetch("http://localhost:5084/api/authors")
                .then((res) => res.json())
                .then((data) => setAuthors(data))
                .catch((err) => console.error("Error fetching authors", err));
        }
    }, [showAuthors]);

    return (
        <div className="min-h-screen bg-base-200 flex flex-col items-center gap-6 p-6">
            <h1 className="text-4xl font-bold font-opensans">Library Books</h1>

            <div className="flex gap-4">
                <button
                    className="btn text-white bg-addGreen hover:opacity-90"
                    onClick={() => setShowForm(true)}
                >
                    Add
                </button>
                <button
                    className="btn text-white bg-deletePink hover:opacity-90"
                    onClick={() => {
                        // TODO: if I have time I will do delete function
                    }}
                >
                    Delete
                </button>
                <button
                    className="btn text-white bg-authorBlue hover:opacity-90"
                    onClick={() => setShowAuthors(true)}
                >
                    See Author
                </button>
            </div>

            {showForm && <BookForm onClose={() => setShowForm(false)} />}

            <div className="grid grid-cols-3 gap-6 w-full max-w-5xl mt-6">
                <div className="bg-white shadow p-4 rounded-lg">
                    <h2 className="text-xl font-bold mb-2">Books</h2>
                    <ul className="list-disc ml-6">
                        {books.map((b) => (
                            <li key={b.id}>
                                <strong>{b.title}</strong> – {b.author?.name} ({b.genre?.name})
                            </li>
                        ))}
                    </ul>
                </div>

                {showAuthors && (
                    <div className="bg-white shadow p-4 rounded-lg">
                        <h2 className="text-xl font-bold mb-2">Authors</h2>
                        <ul className="list-disc ml-6">
                            {authors.map((a) => (
                                <li key={a.id}>{a.name}</li>
                            ))}
                        </ul>
                    </div>
                )}

                <div className="bg-white shadow p-4 rounded-lg">
                    <h2 className="text-xl font-bold mb-2">Genres</h2>
                    <ul className="list-disc ml-6">
                        {genres.map((g) => (
                            <li key={g.id}>{g.name}</li>
                        ))}
                    </ul>
                </div>
            </div>
        </div>
    );
}
