using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle Application vide, consultez la page http://go.microsoft.com/fwlink/?LinkId=391641

namespace SampleApp.WinPhone8._1
{
    using RoundedBoxView.Forms.Plugin.WindowsPhone8._1;

    /// <summary>
    /// Fournit un comportement spécifique à l'application afin de compléter la classe Application par défaut.
    /// </summary>
    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        /// <summary>
        /// Initialise l'objet d'application de singleton.  Il s'agit de la première ligne du code créé
        /// à être exécutée. Elle correspond donc à l'équivalent logique de main() ou WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoqué lorsque l'application est lancée normalement par l'utilisateur final.  D'autres points d'entrée
        /// sont utilisés lorsque l'application est lancée pour ouvrir un fichier spécifique, pour afficher
        /// des résultats de recherche, etc.
        /// </summary>
        /// <param name="e">Détails concernant la requête et le processus de lancement.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Ne répétez pas l'initialisation de l'application lorsque la fenêtre comporte déjà du contenu,
            // assurez-vous juste que la fenêtre est active
            if (rootFrame == null)
            {
                // Créez un Frame utilisable comme contexte de navigation et naviguez jusqu'à la première page
                rootFrame = new Frame();

                // TODO: modifier cette valeur à une taille de cache qui contient à votre application
                rootFrame.CacheSize = 1;

                // Définir la page par défaut
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                // Xamarin init
                Xamarin.Forms.Forms.Init(e);
                RoundedBoxViewRenderer.Init();

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: chargez l'état de l'application précédemment suspendue
                }

                // Placez le frame dans la fenêtre active
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Supprime la navigation tourniquet pour le démarrage.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                // Quand la pile de navigation n'est pas restaurée, accédez à la première page,
                // puis configurez la nouvelle page en transmettant les informations requises en tant que
                // paramètre
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Vérifiez que la fenêtre actuelle est active
            Window.Current.Activate();
        }

        /// <summary>
        /// Restaure les transitions de contenu une fois l'application lancée.
        /// </summary>
        /// <param name="sender">Objet où le gestionnaire est attaché.</param>
        /// <param name="e">Détails sur l'événement de navigation.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        /// <summary>
        /// Appelé lorsque l'exécution de l'application est suspendue.  L'état de l'application est enregistré
        /// sans savoir si l'application pourra se fermer ou reprendre sans endommager
        /// le contenu de la mémoire.
        /// </summary>
        /// <param name="sender">Source de la requête de suspension.</param>
        /// <param name="e">Détails de la requête de suspension.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: enregistrez l'état de l'application et arrêtez toute activité en arrière-plan
            deferral.Complete();
        }
    }
}