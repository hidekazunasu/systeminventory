# systeminventory

#### データベースについて  

```mermaid
erDiagram
    SystemCategories {
        Id integer
        Name text
    }
    ProcessControl {
        Id integer
        Name text
    }
    system {
        Id text
        SystemCategory integer
        Name text
        Detail text
        ProcessControl int
    }

    SystemCategories }|--|| system:""
    ProcessControl }|--|| system:""

```
