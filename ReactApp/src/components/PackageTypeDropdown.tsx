import { FunctionComponent } from "react";
import { PackageTypeDto } from "../services/swaggerapi/data-contracts";

interface SelectProps {
    PackageTypes: Array<PackageTypeDto>
    onSelectClick?: (event: React.MouseEvent, value: string) => void
  }

const PackageTypeDropdown = (props: SelectProps) => {
    const dropdownListe =
    props.PackageTypes.length > 0 &&
    props.PackageTypes.map((item) => {
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
        //onChange={(e) => handleSelectedFag(e)}
        className='item form-select'
        style={{ width: 'auto', maxWidth: '40rem' }}
      >
        {dropdownListe}
      </select>
        </div>
    )
}

export default PackageTypeDropdown;