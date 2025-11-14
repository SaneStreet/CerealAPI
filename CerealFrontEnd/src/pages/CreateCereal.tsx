import { crtCereal } from "../api/cereals";
import { useNavigate } from "react-router-dom";
import CerealForm from "../components/CerealForm";

export default function CreateCereal() {
  const navigate = useNavigate();

  const handleCreate = async (data: any) => {
    await crtCereal(data);
    alert("Cereal created!");
    navigate("/cereals");
  };

  return (
    <div className="p-8 max-w-md mx-auto">
      <h2 className="text-2xl font-bold mb-4">Create New Cereal</h2>
      <CerealForm onSubmit={handleCreate} submitLabel="Create" />
    </div>
  );
}