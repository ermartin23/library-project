// src/pages/BooksPage.tsx
import { useState } from "react";
import BookForm from "../components/BookForm";
import BookList from "../components/BookList";

export default function BooksPage() {
    const [showForm, setShowForm] = useState(false);

    return (
        <div className="min-h-screen bg-base-100 flex flex-col items-center justify-center font-opensans">
            <h1 className="text-4xl font-bold mb-6">Library Books</h1>

            {/* Botones principales */}
            <div className="flex gap-4 mb-6">
                <button
                    className="btn text-white bg-addGreen hover:opacity-90"
                    onClick={() => setShowForm(true)}
                >
                    Add
                </button>
                <button
                    className="btn text-white bg-deletePink hover:opacity-90"
                    onClick={() => alert("Delete trigger works!")}
                >
                    Delete
                </button>
                <button
                    className="btn text-white bg-authorBlue hover:opacity-90"
                    onClick={() => alert("See Author trigger works!")}
                >
                    See Author
                </button>
            </div>

            {/* Formulario al hacer Add */}
            {showForm && <BookForm onClose={() => setShowForm(false)} />}

            {/* Lista de libros */}
            <BookList />
        </div>
    );
}
