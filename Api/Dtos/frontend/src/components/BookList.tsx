// frontend/src/components/BookList.tsx
import { useEffect, useState } from "react";
import { getBooks } from "../services/api";

interface Book {
    id: number;
    title: string;
    authorId: number;
    genreId: number;
    authorName: string;
    genreName: string;

}

export default function BookList() {
    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getBooks()
            .then((data) => {
                setBooks(data);
                setLoading(false);
            })
            .catch((error) => {
                console.error("Error fetching books:", error);
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading books...</p>;
    }
    return (
        <div className="p-4 bg-white shadow-lg rounded-xl mt-6 w-96">
            <h2 className="text-xl font-bold mb-3">Books</h2>
            <ul className="list-disc list-inside space-y-2">
                {books.map((book) => (
                    <li key={book.id} className="text-gray-700">
                        {book.title} – {book.authorName} ({book.genreName})
                    </li>
                ))}
            </ul>
        </div>
    );
}
