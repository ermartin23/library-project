// src/App.tsx
import { useState } from "react";
import BookForm from "./components/BookForm";
import BookList from "./components/BookList";

export default function App() {
    const [showForm, setShowForm] = useState(false);

    console.log("App rendered"); // Debug

    return (
        <div className="min-h-screen bg-base-200 flex flex-col items-center justify-center gap-6">
            <h1 className="text-4xl font-bold font-opensans">Library Books</h1>

            {/* Solo tus botones custom con colores */}
            <div className="flex gap-4">
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

            {showForm ? <BookForm onClose={() => setShowForm(false)} /> : null}

            <BookList />
        </div>
    );
}
