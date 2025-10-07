// frontend/src/components/AuthorList.tsx
import { useEffect, useState } from "react";
import { getAuthors } from "../services/api";

interface Author {
    id: number;
    name: string;
}

export default function AuthorList() {
    const [authors, setAuthors] = useState<Author[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getAuthors()
            .then((data) => {
                setAuthors(data);
                setLoading(false);
            })
            .catch((err) => {
                console.error("Error fetching authors:", err);
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading authors...</p>;
    }

    return (
        <div className="p-4 bg-white shadow-lg rounded-xl mt-6 w-96">
            <h2 className="text-xl font-bold mb-3">Author List</h2>
            <ul className="list-disc list-inside space-y-2">
                {authors.slice(0, 5).map((a) => (
                    <li key={a.id} className="text-gray-700">
                        {a.name}
                    </li>
                ))}
            </ul>
        </div>
    );
}
