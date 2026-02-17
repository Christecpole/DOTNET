# Exercice Docker #5 - Création d'un serveur web via Dockerfile

## Objectifs

Appréhender le fonctionnement de Docker et des Dockerfiles

## Sujet

Via l'utilisation de Docker Desktop, d'un fichier Dockerfile ainsi qu'un site web préfait disponible sur notre ordinateur, réaliser le déploiement d'un serveur web personnalisé: 

* Trouver et utiliser une image de serveur web NGINX

* Créer un site web en local (dans un dossier à part de votre ordinateur)

* Ecrire le contenu d'un fichier Dockerfile dans le but de faire une image maison (le fichier devrait idéalement se trouver dans le projet de site web)

* Compiler l'image de notre site web via les commandes Docker

* Vérifier le résultat via un appel HTTP depuis votre propre ordinateur (la redirection de port est nécessaire pour que le traffic passe)

## Correction 

* Trouver et utiliser une image de serveur web NGINX

```bash
docker search nginx
```

* Créer un site web en local (dans un dossier à part de votre ordinateur)

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exercice 05</title>
</head>
<body>
    <main>
        <h1>Exercice 05</h1>
        <p>Bienvenue sur le site de l'exercice 05!</p>
        <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Saepe quam iusto voluptatibus debitis fuga dolorem? Odio, voluptate, expedita explicabo quibusdam, officia sed id necessitatibus blanditiis illo voluptas dolorem aperiam quas.
        Facilis dolores culpa accusantium fugit? Corporis consectetur nisi optio porro facere rem, veniam vel officiis laudantium tenetur ipsam doloribus architecto assumenda dolorem amet tempora molestias. Expedita perspiciatis iusto sequi nostrum.
        Quod eveniet in praesentium est magni totam, quam deserunt sunt minima quas placeat, veritatis, distinctio corporis nulla tempore saepe eaque nesciunt ex cum delectus hic ut! Quia voluptatibus atque natus.
        Consequuntur architecto maxime eligendi. Aut, assumenda delectus quasi, eius eaque quae repellat aliquid officiis dolore quia eligendi voluptatem quis a laboriosam maxime, nesciunt cum obcaecati totam! Unde autem ea eos.
        In unde sint voluptate officiis quaerat, praesentium voluptatem ab, minima iusto id quam, harum soluta debitis quae quod consequuntur veritatis! Pariatur necessitatibus deleniti sapiente. Itaque adipisci ea provident totam modi.
        At sequi iste harum rerum dolor tenetur amet natus eos dolores soluta nisi minima, unde aliquam necessitatibus nam? Non vero inventore debitis molestias. Architecto laudantium provident ducimus laboriosam necessitatibus optio!
        Sequi tempora molestiae repudiandae aliquam perspiciatis? Consectetur, nihil vero quo sapiente eius dignissimos consequatur illum distinctio natus omnis cum, aliquam fugiat quisquam! Labore neque consequatur rem architecto iusto! Laudantium, quisquam.
        Ipsam, excepturi incidunt quisquam magni ratione corporis. Placeat qui repudiandae omnis facilis pariatur, ad a maiores facere dicta vero sit, saepe reiciendis distinctio modi quibusdam ea eius praesentium, veniam animi!
        Blanditiis, porro sunt! Necessitatibus dignissimos ut provident ipsum deleniti, explicabo totam optio. Facere corporis quia similique nulla impedit, eaque provident culpa. Nam at pariatur quam voluptates accusantium, minus eligendi laboriosam.
        Sequi consequatur hic officiis obcaecati maxime ipsum voluptate a cupiditate blanditiis dolore maiores voluptates animi minima voluptatibus repudiandae, earum, vel odio velit praesentium deleniti similique aliquid iusto! Quo, accusantium nesciunt?
        Culpa quaerat porro libero laboriosam non vel voluptatum tenetur eveniet praesentium, saepe dolorem minus doloribus expedita accusamus impedit esse eaque ad neque pariatur, mollitia ut quibusdam? Distinctio neque laudantium molestiae.
        Magni, explicabo! Magni ullam nostrum amet iste a obcaecati voluptate. Dolores quis dolor magnam provident ipsam deleniti possimus recusandae porro eos repellendus facilis, esse eveniet molestiae quasi ex? Harum, debitis.
        Sed, labore. Sit ipsum neque magni nulla magnam quibusdam dolor, tempora maiores, aliquid illo expedita reiciendis ducimus minus laborum libero odio ipsam. Quis soluta velit, harum asperiores aperiam doloribus incidunt?
        Alias impedit nihil, quisquam asperiores, fugiat in, aut omnis vero facere at quasi. Sint, ea. Ea optio qui voluptatem, rem illo placeat ratione, quas id deleniti modi quam aliquam iusto.
        Libero ducimus adipisci minus qui aperiam voluptate culpa iste dolorem quis assumenda. Consequuntur veritatis porro labore veniam cum error aperiam, voluptatibus temporibus vero, magnam iste unde dolor a aliquid officiis?
        Nam alias illum vel quidem error corrupti quia, aperiam eligendi quod deleniti voluptas vero pariatur placeat earum exercitationem iure facilis! Fugiat velit eligendi minima enim porro voluptatibus harum sit unde!
        Molestias deserunt amet minus eum minima tenetur cumque alias labore iusto ipsa maiores placeat eius nostrum assumenda pariatur adipisci veritatis odio reprehenderit dolores illum voluptatibus, sequi omnis harum! Odit, sunt!
        Dolore nam ipsa quos tenetur et illo perferendis est quaerat dolores exercitationem fugit quae enim facilis sunt explicabo, tempore, sed quis nemo voluptatem eveniet porro aut praesentium nisi! Omnis, optio.
        Facilis, libero quos nemo laborum error sequi assumenda enim quae esse voluptatum harum delectus, unde itaque odio rerum dolorem quisquam placeat dicta impedit iusto ad perferendis ea maxime. Corrupti, optio.
        Aperiam officia natus doloribus reiciendis obcaecati, eaque ea dolorum harum quam at aspernatur molestias, nobis odio molestiae praesentium possimus sint eum nesciunt consectetur quibusdam. Voluptatibus atque odio aliquid repellendus voluptatum.</p>
    </main>
</body>
</html>
```

* Ecrire le contenu d'un fichier Dockerfile dans le but de faire une image maison (le fichier devrait idéalement se trouver dans le projet de site web)

```dockerfile
FROM nginx:alpine

COPY ./index.html /usr/share/nginx/html/index.html
# COPY . /usr/share/nginx/html/ => Si l'on avait plusieurs fichiers dans notre site (CSS, JS, etc.)

CMD ["nginx", "-g", "daemon off;"]
```

* Compiler l'image de notre site web via les commandes Docker

```bash
# Après avoir déplacé / ouvert un terminal à l'emplacement du fichier Dockerfile
docker build -t exercice-05 .
```

* Déployer via Docker un conteneur utilisant notre image custom

```bash
docker run -d -p 8080:80 --name exo-05 exercice-05
```

* Vérifier le résultat via un appel HTTP depuis votre propre ordinateur (la redirection de port est nécessaire pour que le traffic passe)

```bash
curl http://localhost:8080
```