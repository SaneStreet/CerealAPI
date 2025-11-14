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
            <td className="border p-2"><Link to={`/cereals/${c.id}`} className="text-blue-600 underline">
                {c.id}
              </Link></td>
            <td className="border p-2">{c.name}</td>
            <td style={{ padding: '5px' }}>{c.mfr}</td>
            <td style={{ padding: '5px' }}>{c.type}</td>
            <td style={{ padding: '5px' }}>{c.calories}</td>
            <td style={{ padding: '5px' }}>{c.protein}</td>
            <td style={{ padding: '5px' }}>{c.fat}</td>
            <td style={{ padding: '5px' }}>{c.sodium}</td>
            <td style={{ padding: '5px' }}>{c.fiber}</td>
            <td style={{ padding: '5px' }}>{c.carbo}</td>
            <td style={{ padding: '5px' }}>{c.sugars}</td>
            <td style={{ padding: '5px' }}>{c.potass}</td>
            <td style={{ padding: '5px' }}>{c.vitamins}</td>
            <td style={{ padding: '5px' }}>{c.shelf}</td>
            <td style={{ padding: '5px' }}>{c.weight}</td>
            <td style={{ padding: '5px' }}>{c.cups}</td>
            <td style={{ padding: '5px' }}>{c.rating}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}