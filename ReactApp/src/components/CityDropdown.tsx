import { ChangeEvent, FunctionComponent } from "react";
import { PackageTypeDto } from "../services/swaggerapi/data-contracts";

interface SelectProps {
    PackageTypes: Array<PackageTypeDto>
    onSelectClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
  }

const PackageTypeDropdown = (props: SelectProps) => {
  const { PackageTypes, onSelectClick } = props
    const dropdownListe =
    PackageTypes.length > 0 &&
    PackageTypes.map((item) => {
        return (
          <option
            key={`${item.id},${item.name}`}
            id={`${item.id}`}
            value={`${item.name}`}
          >
            {`${item.name}`}
          </option>
        )
      })

    return (
        <div>
            <select
        onChange={onSelectClick}
        className='item form-select'
        style={{ width: 'auto', maxWidth: '40rem' }}
      >
        {dropdownListe}
      </select>
        </div>
    )
}

export default PackageTypeDropdown;