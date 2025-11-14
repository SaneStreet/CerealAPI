import { Link } from "react-router-dom";

export default function Home() {
  return (
    <div className="flex flex-col items-center gap-4 p-8">
      <h1 className="text-3xl font-bold">Manage Cereals</h1>
      <div className="flex gap-4">
        <Link 
            to="/cereals" 
            className="px-4 py-2 rounded-lg border border-blue-400 text-white! hover:bg-blue-500 hover:text-white transition">
              View Cereals
        </Link>
        <Link 
            to="/cereals/new" 
            className="px-4 py-2 rounded-lg border border-green-400 text-white! hover:bg-green-500 hover:text-white transition">
              Create New
        </Link>
      </div>
    </div>
  );
}