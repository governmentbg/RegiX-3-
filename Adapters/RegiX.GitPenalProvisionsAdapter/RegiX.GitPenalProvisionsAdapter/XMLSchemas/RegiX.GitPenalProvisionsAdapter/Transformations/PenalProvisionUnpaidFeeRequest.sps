<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/GIT/RNP"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/GIT/RNP/PenalProvisionUnpaidFeeRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="C:\RegiX\RegiX.GitPenalProvisionsAdapter\XMLSchemas\PenalProvisionUnpaidFeeRequest.xsd" workingxmlfile="C:\RegiX\RegiX.GitPenalProvisionsAdapter\XMLSchemas\Transformations\PenalProvisionUnpaidFeeRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:PenalProvisionUnpaidFeeRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Входни параметри на справка за наказателни постановления на основание неплатени трудови възнаграждения за период"/>										</children>									</paragraph>									<table>										<properties border="0" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell>																<children>																	<text fixtext="ЕИК или БУЛСТАТ на нарушител">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:IntruderIdentifier" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<children>																	<text fixtext="Начална дата на период за търсене на НП">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:DateFrom" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format string="DD.MM.YYYY" datatype="date"/>																			</content>																			<button>																				<styles font-weight="bold"/>																				<action>																					<datepicker/>																				</action>																			</button>																			<text fixtext=" г.">																				<styles font-weight="bold"/>																			</text>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties height="24"/>																<children>																	<text fixtext="Крайна дата на период за търсене на НП">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<properties height="24"/>																<children>																	<template match="n1:DateTo" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format string="DD.MM.YYYY" datatype="date"/>																			</content>																			<button>																				<styles font-weight="bold"/>																				<action>																					<datepicker/>																				</action>																			</button>																			<text fixtext=" г.">																				<styles font-weight="bold"/>																			</text>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>									<newline/>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>