import { ChangeEvent, FunctionComponent } from "react";
import { CityDto } from "../../services/swaggerapi/data-contracts";
import styled from 'styled-components'

const BaseInput = styled.select.attrs((props) => ({
    type: props.type || 'text',
    name: props.name,
    onChange: props.onChange,
    value: props.value,
}))`
  appearance: none;
  color: #1a1a1a;
  display: block;
  font-size: 1.3rem;
  line-height: 1.2rem;
  padding: calc(8px - 1px) calc(16px - 1px);
  width: 100%;
  max-width: 20rem;
  margin-top: 8px;
  margin-bottom: 8px;
  text-align: left;
`
const FLabel = styled.label`
  display: inline-block;
  font-size: 1.3rem;
  line-height: 1.2rem;
  font-weight: 600;
  color: #1a1a1a;
  text-transform: none;
  padding-top: 1.5rem;
  padding-bottom: 1.5rem;
  padding-right: 4px;
  padding-left: 10px;
  max-width: 100px;
  width: 100px;
`

const StyledSelect = styled(BaseInput).attrs((props) => ({
    type: 'text',
}))`
  border: 1px solid #747474;
  border-radius: 4px;
`

interface SelectProps {
    Cities: Array<CityDto>
    Value: string
    onSelectClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
}

const CityDropdown = (props: SelectProps) => {
    const { Cities, onSelectClick, Value } = props
    const dropdownListe =
        Cities?.length! > 0 &&
        Cities.map((item) => {
            return (
                <option
                    key={`${item.id!},${item.name!}`}
                    id={`${item.id!}`}
                    value={`${item.name!}`}
                >
                    {`${item.name}`}
                </option>
            )
        })

    return (
        <div>
            <StyledSelect
                onChange={onSelectClick}
                className='item form-select'
                style={{ width: 'auto', maxWidth: '40rem' }}
                value={Value}
            >
                {dropdownListe}
            </StyledSelect>
        </div>
    )
}

export default CityDropdown;