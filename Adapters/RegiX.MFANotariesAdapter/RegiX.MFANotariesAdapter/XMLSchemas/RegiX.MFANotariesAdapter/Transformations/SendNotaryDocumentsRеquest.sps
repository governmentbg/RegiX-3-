<?xml version="1.0" encoding="UTF-8"?>
<structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/MFA/Notaries/SendNotaryDocumentsRequest"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="..\SendNotaryDocumentsRequest.xsd" workingxmlfile="..\..\..\XMLSamples\RegiX.MFANotariesAdapter\SendNotaryDocumentsRequest.xml">
				<xmltablesupport/>
				<textstateicons/>
			</xsdschemasource>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate match="/" matchtype="named" parttype="main">
				<children>
					<template match="$XML" matchtype="schemasource">
						<editorproperties elementstodisplay="5"/>
						<children>
							<paragraph paragraphtag="h3">
								<properties align="center"/>
								<children>
									<text fixtext="Министерство на външните работи"/>
								</children>
							</paragraph>
							<newline/>
							<paragraph paragraphtag="h2">
								<properties align="center"/>
								<children>
									<text fixtext="Входни параметри на удостоверяване на заверки"/>
								</children>
							</paragraph>
							<table>
								<properties align="center" border="0"/>
								<children>
									<tablebody>
										<children>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Номер на заверка от регистъра"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsRequest" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:AuthenticationNumber" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content/>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Идентификатор (код) на консулска служба"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsRequest" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:ConsulCode" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content/>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Тип на заверка"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsRequest" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:AuthenticationType" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content/>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
											<tablerow>
												<children>
													<tablecell headercell="1">
														<children>
															<text fixtext="Дата на заверка"/>
														</children>
													</tablecell>
													<template match="n1:SendNotaryDocumentsRequest" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<tablecell>
																<children>
																	<template match="n1:AuthenticationDate" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<content>
																				<format string="DD.MM.YYYY &apos;г.&apos;" datatype="date"/>
																			</content>
																		</children>
																	</template>
																</children>
															</tablecell>
														</children>
													</template>
												</children>
											</tablerow>
										</children>
									</tablebody>
								</children>
							</table>
							<newline/>
							<paragraph paragraphtag="h3">
								<properties align="center"/>
								<children>
									<text fixtext="Изпратени документи: "/>
								</children>
							</paragraph>
							<list>
								<children>
									<template match="n1:SendNotaryDocumentsRequest" matchtype="schemagraphitem">
										<editorproperties elementstodisplay="5"/>
										<children>
											<template match="n1:Documents" matchtype="schemagraphitem">
												<editorproperties elementstodisplay="5"/>
												<children>
													<template match="n1:Document" matchtype="schemagraphitem">
														<editorproperties elementstodisplay="5"/>
														<children>
															<template match="n1:FileName" matchtype="schemagraphitem">
																<editorproperties elementstodisplay="5"/>
																<children>
																	<listrow>
																		<children>
																			<content/>
																		</children>
																	</listrow>
																</children>
															</template>
														</children>
													</template>
												</children>
											</template>
										</children>
									</template>
								</children>
							</list>
						</children>
					</template>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<pagelayout/>
	<designfragments/>
</structure>
