import { Link } from "react-router-dom";
import type { Cereal } from "../types";

export default function CerealTable({ cereals }: { cereals: Cereal[] }) {
  return (
    <table className="w-full border-collapse border text-left"
        style={{ 
        borderCollapse: 'collapse', 
        width: '100%', 
        textAlign: 'center', 
        boxShadow: '0 0 10px rgba(0,0,0,0.1)',
      }}>
      <thead>
        <tr>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">ID</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Navn</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">MFR</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Type</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Calories</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Protein</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Fat</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Sodium</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Fiber</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Carbos</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Sugars</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Potass</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Vitamins</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Shelf</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Weight</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Cups</th>
          <th style={{ padding: '12px', borderBottom: '2px solid #FABE19' }} className="border p-2">Rating</th>
        </tr>
      </thead>
      <tbody>
        {cereals.map(c => (
          <tr key={c.id}
            style={{ 
                    borderBottom: '1px solid #FABE19', 
                    transition: 'background-color 0.5s' 
                }}
                onMouseEnter={e => (e.currentTarget.style.backgroundColor = '#fefefe', e.currentTarget.style.color = '#000')}
                onMouseLeave={e => (e.currentTarget.style.backgroundColor = 'transparent', e.currentTarget.style.color = '#fff')}
            >
            <td className="border p-2">
              <Link 
                to={`/cereals/${c.id}`} 
                className="text-blue-600 underline">
                  {c.id}
              </Link>
            </td>
            <td className="border-b-amber-400 p-2">{c.name}</td>
            <td className="border-b-amber-400 p-2">{c.mfr}</td>
            <td className="border-b-amber-400 p-2">{c.type}</td>
            <td className="border-b-amber-400 p-2">{c.calories}</td>
            <td className="border-b-amber-400 p-2">{c.protein}</td>
            <td className="border-b-amber-400 p-2">{c.fat}</td>
            <td className="border-b-amber-400 p-2">{c.sodium}</td>
            <td className="border-b-amber-400 p-2">{c.fiber}</td>
            <td className="border-b-amber-400 p-2">{c.carbo}</td>
            <td className="border-b-amber-400 p-2">{c.sugars}</td>
            <td className="border-b-amber-400 p-2">{c.potass}</td>
            <td className="border-b-amber-400 p-2">{c.vitamins}</td>
            <td className="border-b-amber-400 p-2">{c.shelf}</td>
            <td className="border-b-amber-400 p-2">{c.weight}</td>
            <td className="border-b-amber-400 p-2">{c.cups}</td>
            <td className="border-b-amber-400 p-2">{c.rating}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}