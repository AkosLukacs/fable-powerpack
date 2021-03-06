#r "../_bin/Fornax.Core.dll"
#load "../siteModel.fsx"
#load "default.fsx"

open Html
open SiteModel

type Model = {
    title : string
}

let generate (siteModel : SiteModel) (mdl : Model) (posts : Post list) (content : string) =
    let links =
        posts
        |> List.map (fun p ->
            li [ ]
               [ a [ Href (Default.host + (p.link.Substring(1)))
                     Class "is-fable-blue" ] [ !!p.title ] ]
        )

    let pageContent =
        [ !!content
          ul [ ] links ]

    Default.defaultPage siteModel mdl.title posts pageContent
