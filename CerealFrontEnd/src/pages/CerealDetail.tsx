import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getCereal, updCereal, delCereal } from "../api/cereals";
import type { Cereal } from "../types";
import CerealForm from "../components/CerealForm";
import ConfirmModal from "../components/ConfirmModal";

export default function CerealDetail() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [cereal, setCereal] = useState<Cereal | null>(null);
  const [isDeleting, setIsDeleting] = useState(false);
  const [showConfirm, setShowConfirm] = useState(false);

  useEffect(() => {
    if (id) getCereal(Number(id)).then(setCereal);
  }, [id]);

  const handleUpdate = async (data: Partial<Cereal>) => {
    if (id) {
      await updCereal(Number(id), data);
      alert("Cereal updated!");
      navigate("/cereals");
    }
  };

  const handleDelete = async () => {
    if (!id) return;
    setShowConfirm(true);
  };

  const confirmDelete = async () => {
    if (!id) return;

    try {
      setIsDeleting(true);
      await delCereal(Number(id));
      alert("Cereal deleted!");
      navigate("/cereals");
    } catch (error) {
      console.error(error);
      alert("Kunne ikke slette cereal.");
    } finally {
      setShowConfirm(false);
      setIsDeleting(false);
    }
  };

  if (!cereal) return <p>Indlæser...</p>;

  return (
    <div className="p-8 max-w-md mx-auto">
      <h2 className="text-2xl font-bold mb-4">Edit Cereal #{id}</h2>

      <CerealForm
        initialData={cereal}
        onSubmit={handleUpdate}
        submitLabel="Update"
      />

      <hr className="my-6" />

      <button
        onClick={handleDelete}
        disabled={isDeleting}
        className="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700 disabled:opacity-60"
      >
        {isDeleting ? "Deleting..." : "Delete"}
      </button>

      {showConfirm && (
        <ConfirmModal
          title="Bekræft sletning"
          message={`Er du sikker på, at du vil slette "${cereal.name}"?`}
          confirmText="Ja, slet"
          cancelText="Annuller"
          onConfirm={confirmDelete}
          onCancel={() => setShowConfirm(false)}
        />
      )}
    </div>
  );
}
