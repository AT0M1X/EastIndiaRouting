import { ChangeEvent, FunctionComponent } from "react";
import { CityDto, PackageTypeDto } from "../services/swaggerapi/data-contracts";


interface SelectProps {
    Cities: Array<CityDto>
    onSelectClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
  }

const PackageTypeDropdown = (props: SelectProps) => {
  const { Cities, onSelectClick } = props
    const dropdownListe =
    Cities.length > 0 &&
    Cities.map((item) => {
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