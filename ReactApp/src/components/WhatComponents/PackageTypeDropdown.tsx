import { ChangeEvent, FunctionComponent } from "react";
import { PackageTypeDto, RouteIntegrationRequest } from "../../services/swaggerapi/data-contracts";
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
  font-size: 1.6rem;
  line-height: 2.4rem;
  padding: calc(8px - 1px) calc(16px - 1px);
  width: 100%;
  max-width: 20rem;
  margin-top: 8px;
  margin-bottom: 8px;
  text-align: left;
`
const FLabel = styled.label`
  display: inline-block;
  font-size: 1.6rem;
  line-height: 2.4rem;
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
  max-height: 50px;
  max-width: 100px;
`

const PackageInfoContainer = styled.div`
max-width: 500px;
width: auto;
background-color: #22AAA1;
border-radius: 10px;
display: flex;
  flex-direction: row;
`

const FormLabel = (props) => {
  const { text } = props
  return <FLabel>{text}</FLabel>
}

interface SelectProps {
    InputData: RouteIntegrationRequest
    PackageTypes: Array<PackageTypeDto>
    onSelectClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
  }

const PackageTypeDropdown = (props: SelectProps) => {
  const { InputData, PackageTypes, onSelectClick } = props
    const dropdownListe =
    PackageTypes?.length! > 0 &&
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
        <PackageInfoContainer>
          <FormLabel text={'Choose package type:'} />
            <StyledSelect
        onChange={onSelectClick}
        className='item form-select'
        style={{ width: 'auto', maxWidth: '40rem' }}
        value={InputData?.type! ?? ""}
      >
        {dropdownListe}
      </StyledSelect>
        </PackageInfoContainer>
    )
}

export default PackageTypeDropdown;