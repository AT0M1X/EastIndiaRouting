import { PackageTypeDto, RouteIntegrationRequest } from "../services/swaggerapi/data-contracts"
import PackageInfoInput from "./WhatComponents/PackageInfoInput"
import PackageTypeDropdown from "./WhatComponents/PackageTypeDropdown"
import styled from 'styled-components'

const RowContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin: auto;
  `

interface WhatComponentProps {
    InputData: RouteIntegrationRequest
    PackageTypes: Array<PackageTypeDto>
    handleInputChange?: (event: React.KeyboardEvent, value: string) => void
    onSelectClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
  }

const WhatComponent = (props: WhatComponentProps) => {
    const { InputData, PackageTypes, handleInputChange, onSelectClick} = props

    return (
        <RowContainer>
            <PackageInfoInput InputData={InputData} handleChange={handleInputChange}/>
            <PackageTypeDropdown InputData={InputData} PackageTypes={PackageTypes} onSelectClick={onSelectClick}/>
        </RowContainer>
    )
}

export default WhatComponent