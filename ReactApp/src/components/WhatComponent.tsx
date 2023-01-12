import { PackageTypeDto } from "../services/swaggerapi/data-contracts"
import PackageInfoInput from "./WhatComponents/PackageInfoInput"
import PackageTypeDropdown from "./WhatComponents/PackageTypeDropdown"
import styled from 'styled-components'

const RowContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin-top: 5px;
  margin-bottom: 5px;
  `

interface WhatComponentProps {
    PackageTypes: Array<PackageTypeDto>
    handleInputChange?: (event: React.KeyboardEvent, value: string) => void
    onSelectClick: (e: React.ChangeEvent<HTMLSelectElement>) => void
  }

const WhatComponent = (props: WhatComponentProps) => {
    const { PackageTypes, handleInputChange, onSelectClick} = props

    return (
        <RowContainer>
            <PackageInfoInput handleChange={handleInputChange}/>
            <PackageTypeDropdown PackageTypes={PackageTypes} onSelectClick={onSelectClick}/>
        </RowContainer>
    )
}

export default WhatComponent